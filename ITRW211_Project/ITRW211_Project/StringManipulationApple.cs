using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITRW211_Project
{
    public class StringManipulationApple
    {
        private static List<string[]> ArticlesDetails_Apple = new List<string[]>();

        public string[] refineSite(string[] arr)
        {
            // This is where detail with '!' is manipulated:

            /* array[11] contents:
                 * 0 - Article ID
                 * 1 - Article Link
                 * 2 - Article Heading
                 * 3 - Article Author 
                 * 4 - Article Abstract
                 * 5 - Article Image Link 
                 * 6 - Article articleHTML
                 * 7 - Article Image Path 
                 * 8 - Article Text Processed  ! (this is your boolean to check if you manipulated for the paragraphs before)
                 * 9 - Article Refined Text  !   (store your refined paragraphs here)
                 * 10 - Article Counter !   (this needs 0)
                 */

            return arr;
        }

        public string[] getAuthorImage(string[] arr)
        {
            // This is where detail with '!' is manipulated:

            /* array[11] contents:
                 * 0 - Article ID
                 * 1 - Article Link
                 * 2 - Article Heading
                 * 3 - Article Author !
                 * 4 - Article Abstract
                 * 5 - Article Image Link !
                 * 6 - Article articleHTML
                 * 7 - Article Image Path
                 * 8 - Article Text Processed
                 * 9 - Article Refined Text
                 * 10 - Article Counter
                 */
            return arr;
        }
        public List<string[]> getArticleDetails(string mainHTML)
        {
            // This is where detail with '!' is manipulated:

            /* array[11] contents:
                 * 0 - Article ID !
                 * 1 - Article Link !
                 * 2 - Article Heading !
                 * 3 - Article Author
                 * 4 - Article Abstract !
                 * 5 - Article Image Link
                 * 6 - Article articleHTML
                 * 7 - Article Image Path
                 * 8 - Article Text Processed
                 * 9 - Article Refined Text
                 * 10 - Article Counter
                 */


            return ArticlesDetails_Apple;
        }
    }
}
