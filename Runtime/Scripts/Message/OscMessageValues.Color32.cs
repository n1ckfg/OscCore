using System.Runtime.CompilerServices;
using UnityEngine;

namespace OscCore
{
    public sealed unsafe partial class OscMessageValues
    {
        /// <summary>
        /// Read a single 32-bit RGBA color message element.
        /// Checks the element type before reading & returns default if it's not interpretable as a color.
        /// </summary>
        /// <param name="index">The element index</param>
        /// <returns>The value of the element</returns>
        public Color32 ReadColor32Element(int index)
        {
#if OSCCORE_SAFETY_CHECKS
            if (index >= ElementCount)
            {
                Debug.LogError($"Tried to read message element index {index}, but there are only {ElementCount} elements");
                return default;
            }
#endif
            switch (Tags[index])
            {
                case TypeTag.Color32:
                    return *(Color32*) (SharedBufferPtr + Offsets[index]);
                default:
                    return default;
            }
        }
        
        /// <summary>
        /// Read a single 32-bit RGBA color message element, with NO TYPE SAFETY CHECK!
        /// Only call this if you are really sure that the element at the given index is a valid float,
        /// as the performance difference is small.
        /// </summary>
        /// <param name="index">The element index</param>
        /// <returns>The value of the element</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Color32 ReadColor32ElementUnchecked(int index)
        {
#if OSCCORE_SAFETY_CHECKS
            if (index >= ElementCount)
            {
                Debug.LogError($"Tried to read message element index {index}, but there are only {ElementCount} elements");
                return default;
            }
#endif
            return *(Color32*) (SharedBufferPtr + Offsets[index]);
        }
    }
}