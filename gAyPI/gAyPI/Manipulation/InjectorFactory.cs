﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.Manipulation
{
    public abstract class InjectorFactory
    {
        public InjectorFactory() { }

        public InjectorFactory(string path)
        {
            UpdatePath(path);
        }

        protected abstract void UpdatePath(string path);

        protected abstract Injector CreateInterfaceInjector(InterfaceInjectorParams @params);

        protected abstract Injector CreateFieldDetourInjector(FieldDetourInjectorParams @params);

        protected abstract Injector CreateFieldAccessorInjector(FieldAccessorInjectorParams @params);

        protected abstract Injector CreateAbsoluteCallInjector(AbsoluteCallInjectorParams @params);

        protected abstract Assembly ToConcrete();

        public InjectionFactoryContext ParseOfType(DataFormat format, Stream @in)
        {
            var ctx = new InjectionFactoryContext();
            ctx.Injectors = new List<Injector>();

            switch (format)
            {
                case DataFormat.Json:
                    ctx.Injectors = ParseJson(@in);
                    break;
            }

            ctx.GetConcreteAssembly = () => ToConcrete();
            return ctx;
        }

        private List<Injector> ParseJson(Stream @in)
        {
            var reader = new StreamReader(@in);
            var json = reader.ReadToEnd();

            var list = new List<Injector>();
            var container = JsonConvert.DeserializeObject<JsonInjectorContainer>(json);

            foreach (var injector in container.InterfaceInjectors)
            {
                list.Add(CreateInterfaceInjector(new InterfaceInjectorParams
                {
                    OwnerType = injector.OwnerType,
                    InterfaceType = injector.InterfaceType,
                }));
            }

            foreach (var injector in container.FieldDetourInjectors)
            {
                list.Add(CreateFieldDetourInjector(new FieldDetourInjectorParams
                {
                    OwnerType = injector.OwnerType,
                    OwnerFieldName = injector.OwnerFieldName,
                    OwnerFieldType = injector.OwnerFieldType,
                    DetourType = injector.DetourType,
                    DetourMethodName = injector.DetourMethodName,
                    DetourMethodDesc = injector.DetourMethodDesc
                }));
            }

            foreach (var injector in container.FieldAccessorInjectors)
            {
                list.Add(CreateFieldAccessorInjector(new FieldAccessorInjectorParams
                {
                    OwnerType = injector.OwnerType,
                    OwnerFieldName = injector.OwnerFieldName,
                    OwnerFieldType = injector.OwnerFieldType,
                    MethodName = injector.MethodName,
                    IsStatic = injector.IsStatic,
                }));
            }

            foreach (var injector in container.AbsoluteCallInjectors)
            {
                list.Add(CreateAbsoluteCallInjector(new AbsoluteCallInjectorParams
                {
                    OwnerType = injector.OwnerType,
                    OwnerMethodName = injector.OwnerMethodName,
                    OwnerMethodDesc = injector.OwnerMethodDesc,
                    DetourType = injector.DetourType,
                    DetourMethodName = injector.DetourMethodName,
                    DetourMethodDesc = injector.DetourMethodDesc,
                    InsertionIndex = injector.InsertionIndex
                }));
            }

            return list;
        }
    }
}
