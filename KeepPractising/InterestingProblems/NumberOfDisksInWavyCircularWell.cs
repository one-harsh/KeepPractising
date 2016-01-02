using KeepPractising.Stacks;

namespace KeepPractising.InterestingProblems
{
    /// <summary>
    /// This class presents a solution for a well which has circular rings with same centre but the ring diameters are not strictly in increasing or decreasing order
    /// and the problem is to find out the number of circular disks that can be inserted. 
    /// The solution considers that the given disk array has disks of various diameters and is not ordered by its radius size either.
    /// The ring height of both well and disk, however, are constant and equal.
    /// <para />For example, well's ring radius array could be { 5, 6, 7, 3, 4, 7 } and disk's radius array could be { 2, 4, 1, 6 }
    /// <para />The solution runs in O(numberOfWellRings) time and uses O(numberOfWellRings) space.
    /// </summary>
    public class NumberOfDisksInWavyCircularWell
    {
        /// <summary>
        /// This method computes the count of disks that can be placed in the well with a given radii array.
        /// </summary>
        /// <param name="wellRingRadius">The radii array of the well's rings</param>
        /// <param name="diskRadius">The radii array of disks to be placed</param>
        /// <returns>The count of disks that can be placed in the well</returns>
        public static int FindNumberOfDisksThatCanBePlaced(int[] wellRingRadius, int[] diskRadius)
        {
            var decreasingRingRadiusFromTop = PlaceTheFirstRadiusAndFindDecreasingRingRadiusStack(wellRingRadius, diskRadius[0]);
            var count = 0;

            if (decreasingRingRadiusFromTop.Length == 0)
                return count;

            // As the first disk would take its position on the ring whose radius sits on top of the stack, we would pop the stack as this would already be occupied by this first disk.
            decreasingRingRadiusFromTop.Pop();
            count++;

            while (decreasingRingRadiusFromTop.Length != 0 && diskRadius.Length > count)
            {
                if (decreasingRingRadiusFromTop.Peek() >= diskRadius[count])
                    count++;

                decreasingRingRadiusFromTop.Pop();
            }

            return count;
        }

        /// <summary>
        /// This method returns a stack which contains an equivalent decreasing ring radius of the well.
        /// <para />
        /// As we move down the well, it really doesn't matter how big the current ring's radius is, if the upper ring radius is not big enough to let the disk pass through.
        /// So we push the smaller of the two radii of the adjacent rings to the stack.
        /// </summary>
        /// <param name="wellRingRadius">The radii array of the well's rings</param>
        /// <param name="diskRadius">The radius of the disk which is to be placed in the well</param>
        /// <returns>The radii stack which forms a decreasing ring radius of the well rings from top</returns>
        private static MyStack<int> PlaceTheFirstRadiusAndFindDecreasingRingRadiusStack(int[] wellRingRadius, int diskRadius)
        {
            var decreasingRadiusStack = new MyStack<int>();
            var i = 0;
            var radiusToBePushed = 0;

            while (i < wellRingRadius.Length && wellRingRadius[i] >= diskRadius)
            {
                if (i != 0)
                    radiusToBePushed = decreasingRadiusStack.Peek() < wellRingRadius[i] ? decreasingRadiusStack.Peek() : wellRingRadius[i];
                else
                    radiusToBePushed = wellRingRadius[i];

                decreasingRadiusStack.Push(radiusToBePushed);
                i++;
            }

            return decreasingRadiusStack;
        }
    }
}
