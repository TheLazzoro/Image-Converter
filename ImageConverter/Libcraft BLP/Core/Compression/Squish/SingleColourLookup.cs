// TODO: Break this out into a real library
// <auto-generated>

namespace Warcraft.Core.Compression.Squish
{
    internal struct SingleColourLookup
    {
        public SourceBlock[] Sources;

        public SingleColourLookup(SourceBlock one, SourceBlock two)
        {
            Sources = new SourceBlock[2];
            Sources[0] = one;
            Sources[1] = two;
        }
    }
}