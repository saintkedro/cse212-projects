using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // Create a HashSet to store all words for fast lookup
        HashSet<string> wordSet = new HashSet<string>(words);

        //List to store the resulting symmetric pairs
        List<string> result = new List<string>();

        // Iterate through rach word in the input array - O(n)
        foreach (string word in words)
        {
            // Since each word has exactly two characters, reverse it manually
            string reverse = "" + word[1] + word[0];

            // Check if any duplicates exist and avoid cases like aa

            if (wordSet.Contains(reverse) && word[0] != word[1])
                if (string.Compare(word, reverse) < 0 )
                {
                    result.Add($"{word} & {reverse}");
                }

        }

        return result.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");

            string degree = fields[3].Trim();

            // If we have seen this degree before, increase its count
            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++;
            }
            // Otherwise, add it to the dictionary with count 1
            else
            {
                degrees[degree] = 1;
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // Remove spaces and convert to lowercase
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        // If lengths are different after removing spaces, they cannot be anagrams
        if (word1.Length != word2.Length)
            return false;

        // Create a dictionary to count letters in word1
        Dictionary<char, int> letterCounts = new Dictionary<char, int>();

        // Count letters in word1
        foreach (char c in word1)
        {
            if (letterCounts.ContainsKey(c))
                letterCounts[c]++;
            else
                letterCounts[c] = 1;
        }

        // Subtract counts using letters from word2
        foreach (char c in word2)
        {
            // If letter is not in dictionary, words are not anagrams
            if (!letterCounts.ContainsKey(c))
                return false;

            letterCounts[c]--;

            // If count goes below zero, word2 has too many of this letter
            if (letterCounts[c] < 0)
                return false;
        }

        // if all letters matched correctly, they are anagrams
        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5: 
        // Create a list to store the summary strings
        List<string> summary = new List<string>();

        // Loop through each earthquake
        foreach (var feature in featureCollection.Features)
        {
            string place = feature.Properties.Place ?? "Unknown location";
            double? magnitude = feature.Properties.Mag;

            // skip earthquake with null magnitude
            if (magnitude == null)
                continue;

            // Add a string describing this earthquake
            summary.Add($"Mag {magnitude} - {place}");
        }

        // Return an array of strings
        return summary.ToArray();
    }
}

        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        
    
