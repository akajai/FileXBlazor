using FileXBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileXBlazor.Helper
{
    public class FileSearcher
    {
        private bool isPaused = false;

        public async Task SearchFilesAsync(string directoryPath, List<SearchResult> searchResults, CancellationToken cancellationToken)
        {
            // Reset the search results list
            searchResults.Clear();

            try
            {
                // Start the file search in a background thread
                await Task.Run(() =>
                {
                    // Use Parallel.ForEach to process files in parallel
                    Parallel.ForEach(Directory.EnumerateFiles(directoryPath, "*", SearchOption.AllDirectories), (filePath, state) =>
                    {
                        cancellationToken.ThrowIfCancellationRequested();

                        var fileInfo = new FileInfo(filePath);

                        // Check if the file is larger than 10 MB
                        if (fileInfo.Length > 10 * 1024 * 1024) // 10 MB in bytes
                        {
                            lock (searchResults)
                            {
                                // Update the searchResults list with the found directory path, file count, and combined size
                                var directoryInfo = new DirectoryInfo(Path.GetDirectoryName(filePath));
                                var directoryPath = directoryInfo.FullName;
                                var directoryResult = searchResults.FirstOrDefault(result => result.DirectoryPath == directoryPath);

                                if (directoryResult == null)
                                {
                                    directoryResult = new SearchResult { DirectoryPath = directoryPath };
                                    searchResults.Add(directoryResult);
                                }

                                //Interlocked.Increment(ref directoryResult.FileCount);
                                //Interlocked.Add(ref directoryResult.CombinedSize, fileInfo.Length);
                            }
                        }
                    });
                }, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                // Handle the cancellation if the search is paused or canceled
            }
        }

        public void PauseSearch()
        {
            isPaused = true;
        }

        public void ResumeSearch()
        {
            isPaused = false;
        }
    }

}
