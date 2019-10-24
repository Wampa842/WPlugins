/*
Copyright (C) 2018 Wampa842

This file is part of WPlugins.

WPlugins is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

WPlugins is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with WPlugins.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WPlugins.Common
{
    /// <summary>
    /// A semantic version that consists of three numbers (major.minor.revision).
    /// </summary>
    [Serializable]
    public class SemanticVersion : IComparable<SemanticVersion>, IEquatable<SemanticVersion>
    {
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Revision { get; set; }

        public SemanticVersion()
        {
            Major = 0;
            Minor = 0;
            Revision = 0;
        }

        public SemanticVersion(int major, int minor, int revision)
        {
            Major = major;
            Minor = minor;
            Revision = revision;
        }

        public override string ToString()
        {
            return Major.ToString() + '.' + Minor.ToString() + '.' + Revision.ToString();
        }

        public int CompareTo(SemanticVersion other)
        {
            int result = Major.CompareTo(other.Major);
            if (result != 0)
                return result;
            result = Minor.CompareTo(other.Minor);
            if (result != 0)
                return result;
            return Revision.CompareTo(other.Revision);
        }

        public bool Equals(SemanticVersion other)
        {
            return this.CompareTo(other) == 0;
        }

        /// <summary>
        /// Parse a semantic version from a major.minor.revision string.
        /// </summary>
        public static SemanticVersion Parse(string str)
        {
            string[] split = str.Trim().Split('.');

            int maj, min, rev;
            // The first number must be present.
            if (split.Length <= 0 || !int.TryParse(split[0], out maj))
                throw new FormatException("The given string cannot be parsed as a semantic version (major is not a number).");

            // If the second number is not present, it is assumed that the minor version and revision are both 0.
            if (split.Length == 1)
                return new SemanticVersion(maj, 0, 0);

            // If a second number is present, try to parse it.
            if(!int.TryParse(split[1], out min))
                throw new FormatException("The given string cannot be parsed as a semantic version (minor is not a number).");

            // The revision is also optional...
            if(split.Length == 2)
            {
                return new SemanticVersion(maj, min, 0);
            }

            // ...but must be parseable if present.
            if(!int.TryParse(split[2], out rev))
                throw new FormatException("The given string cannot be parsed as a semantic version (revision is not a number).");

            // The rest of the string can be ignored. At this point, all numbers should've been parsed and a semver can be returned.
            return new SemanticVersion(maj, min, rev);
        }

        /// <summary>
        /// Try to parse a semantic version from a string. The return value indicates whether the parse was successful.
        /// </summary>
        public static bool TryParse(string str, out SemanticVersion version)
        {
            string[] split = str.Trim().Split('.');

            int maj, min, rev;
            // The first number must be present.
            if (split.Length <= 0 || !int.TryParse(split[0], out maj))
            {
                version = new SemanticVersion(0, 0, 0);
                return false;
            }

            // If the second number is not present, it is assumed that the minor version and revision are both 0.
            if (split.Length == 1)
                version = new SemanticVersion(maj, 0, 0);

            // If a second number is present, try to parse it.
            if (!int.TryParse(split[1], out min))
            {
                version = new SemanticVersion(maj, 0, 0);
                return false;
            }

            // The revision is also optional...
            if (split.Length == 2)
            {
                version = new SemanticVersion(maj, min, 0);
            }

            // ...but must be parseable if present.
            if (!int.TryParse(split[2], out rev))
            {
                version = new SemanticVersion(maj, min, 0);
                return false;
            }

            version = new SemanticVersion(maj, min, rev);
            return true;
        }
    }
}
