﻿/*
    Copyright 2016 Cody R. (Demmonic)

    Storm is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Storm is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Storm.  If not, see <http://www.gnu.org/licenses/>.

                              .       .
                         / `.   .' \
                 .---.  <    > <    >  .---.
                 |    \  \ - ~ ~ - /  /    |
                  ~-..-~             ~-..-~
              \~~~\.'                    `./~~~/
    .-~~^-.    \__/                        \__/
  .'  O    \     /               /       \  \
 (_____,    `._.'               |         }  \/~~~/
  `----.          /       }     |        /    \__/
        `-.      |       /      |       /      `. ,~~|
            ~-.__|      /_ - ~ ^|      /- _      `..-'   f: f:
                 |     /        |     /     ~-.     `-. _||_||_
                 |_____|        |_____|         ~ - . _ _ _ _ _>

 */
using Storm.StardewValley.Accessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Wrapper
{
    public class Object : Item
    {
        private ObjectAccessor accessor;

        public Object(ObjectAccessor accessor) : base(accessor)
        {
            this.accessor = accessor;
        }

        public string GetName()
        {
            return accessor._GetName();
        }
    }
}