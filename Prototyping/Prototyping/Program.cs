using System;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        const string API_KEY = "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";
        const string outputDirectory = "output_html_files";

        Directory.CreateDirectory(outputDirectory);

        // Define image URLs


        string image1 = "https://www.southernliving.com/thmb/1OFoAHNd3lGNqx74iQ8riscZdCA=/750x0/filters:no_upscale%28%29:max_bytes%28150000%29:strip_icc%28%29:format%28webp%29/Southern-Living-Homemade_Brownies_023-3c582f0fba1842dd918a3d9c26c1ab59.jpg";
        string image2 = "https://wallpapercave.com/wp/wp5461043.jpg";
        string image3 = "https://www.sheknows.com/wp-content/uploads/2018/08/yvndhqlawlsljlyaqob6.jpeg?w=1920";
        string image4 = "https://img.freepik.com/free-vector/contact-us-concept-landing-page_52683-12873.jpg";
        string image5 = "https://m.media-amazon.com/images/I/41jLBhDISxL.jpg";


        // Define the common pattern for HTML pages
        const string pattern = @"
<!DOCTYPE html>
<html>
<head>
    <title>ABC Restraunts</title>
</head>
<body>
    <h1>Welcome to Page 2</h1>
    <a href='#'>Home</a>
    <a href='Receipes.html'>Receipes</a>
    <a href='Tips.html'>Tips</a>
    <a href='Contact.html'>Contact</a>
    <a href='ProfilePage.html'>Profile</a>
</body>
</html>
";
        string[] filenames = new string[] { "Home", "ProfilePage", "Receipes", "Tips", "Contact" };


        string[] prompts = new string[]
  {
    @"
Objective:
Create an HTML page with an olive red background. The page should include a header section containing a bold, white text displaying 'My Food' on the top left corner. A group of links including 'Home,' 'Receipes,' 'Tips,' 'Contact,' and 'Profile' should be aligned towards the right of the header.

Divide the page into two vertical sections. The left section should include a centered heading 'Brownie Magic' " + image1 + @" with a subtext 'How to make the best brownie in the game.' Below the heading, add the text 'There's nothing like a batch of homemade brownies to satisfy your sweet tooth. These brownies are rich, fudgy, and easy to make with just a few ingredients. You can customize them with your favorite toppings, such as nuts, chocolate chips, or marshmallows. They're perfect for any occasion, whether it's a birthday, a potluck, or just a cozy night in.' Insert a black button with white text reading 'Get Receipes' at the bottom of this text. Ensure that the entire text section is centered within its division.

The right section of the page should display an image sourced from the URL " + image1 + @". Apply appropriate padding and margins to ensure the image fits well within the section and use this pattern " + pattern + @" and first Character of other html pages should be starts with Capital letter.
    ",

    @"
Objective:
Design a basic profile webpage for John Doe with Inline CSS.

Context:
As an experienced web designer, you are tasked with creating a simple yet visually appealing profile page to introduce John Doe. The page should effectively present his name, a brief bio, an image, and contact information.

Expert Persona:
Experienced web designer with a knack for crafting attractive and user-friendly web pages.

Purpose:
The goal is to craft a clean and engaging profile page that showcases John Doe's background and contact details in an aesthetically pleasing manner.

Design Considerations:
1. Choose a color scheme that resonates with John Doe's personality " + image5 + @".
2. Ensure the layout is responsive and looks good on both desktop and mobile devices.
3. Incorporate appropriate fonts and typography to enhance readability.
4. Use subtle animations or transitions to add visual interest.
5. Pay attention to spacing and alignment for a polished appearance.

pattern:
" + pattern + @"
first Character of other html pages should be starts with Capital letter
    ",

    @"
Objective:
Design an enticing HTML page for a delightful receipes with Inline CSS

Context:
As a skilled chef who takes pleasure in sharing culinary creations, you're tasked with creating an attractive receipes page that showcases the details of a delectable [Food Item] dish. The page should effectively present the receipes name, a tempting image, a list of ingredients, step-by-step instructions, and creative variations for added flair.

Expert Persona:
Experienced chef with a deep passion for sharing gastronomic delights through thoughtfully designed web pages.

Purpose:
The objective is to craft an alluring receipes page that serves as a comprehensive guide to preparing the scrumptious [Food Item] dish, while also highlighting its unique features and potential adaptations.

Design Considerations:
1. Select colors that evoke appetite and harmony with the dish in Cards .
2. Ensure a visually appealing layout that is easy to navigate.
3. Incorporate high-quality images" + image2 + @" that showcase the dish's appearance in Cards format.
4. Choose fonts that complement the overall vibe of the receipes.
5. Use clear and concise typography to enhance readability.
6. Integrate subtle design elements that add to the culinary experience in Cards format with transition.

Pattern:
" + pattern + @"
    ",

    @"
Objective:
Design an insightful HTML page featuring useful tips for cooking the ultimate  dish with Inline CSS.

Context:
As an experienced chef committed to imparting culinary wisdom, your goal is to create an engaging tips page that offers valuable insights, practical recommendations, and expert techniques for mastering the art of preparing the [Food Item] receipes. The page should serve as a treasure trove of knowledge to enhance the cooking journey.

Expert Persona:
Skilled chef with a passion for sharing expertise and empowering home cooks to excel in their culinary endeavors.

Purpose:
The purpose is to craft an informative and user-friendly tips page that equips cooks with the guidance and knowledge required to achieve culinary excellence while preparing the delightful [Food Item] dish.

Design Considerations:
1. Choose a color scheme that resonates with the theme of the [Food Item] dish.
2. Create a layout that encourages easy navigation and readability.
3. Incorporate appealing visuals, such as high-quality images " + image3 + @" or illustrations.
4. Utilize typography that enhances the presentation of valuable tips.
5. Maintain a clean and organized design to facilitate information absorption.
6. Add interactive elements or visuals that support the cooking tips.

Pattern:
" + pattern + @"
    ",

    @"
Objective:
Design a user-friendly HTML page featuring contact details with Inline CSS.

Context:
As a skilled web designer dedicated to enhancing user experience, your task is to create an accessible contact page that provides customers with essential information to connect with [Restaurant Name]. The page should be designed with clarity and functionality in mind, offering the restaurant's address, phone number, email, and a convenient contact form for inquiries.

Expert Persona:
Experienced web designer with a track record of creating informative and user-friendly contact pages that facilitate seamless communication between businesses and customers.

Purpose:
The purpose of this project is to develop a comprehensive contact page that serves as a bridge between Indian food and its customers. The page should enable easy and efficient communication, enhancing customer engagement and satisfaction.

Design Considerations:
1.Use the Inline CSS for Styling the Contact page in header with images " + image4 + @"
2. style the input fields properly with appropriate width height.
3. Button should be well structure

pattern:
" + pattern + @"
    ",
  };


        var httpClient = new HttpClient();
        httpClient.Timeout = TimeSpan.FromMinutes(5);
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {API_KEY}");


        for (int i = 0; i < prompts.Length; i++)
        {
            string prompt = prompts[i];
            string filename = $"output_html_files/" + filenames[i] + ".html";

            var requestBody = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new
                    {
                        role = "user",
                        content = prompt
                    }
                },
                max_tokens = 1500,
                temperature = 0.7
            };

            var response = await httpClient.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", requestBody);
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsAsync<dynamic>();

            if (data.choices != null && data.choices.Count > 0)
            {
                string content = data.choices[0].message.content;

                await File.WriteAllTextAsync(filename, content);
                Console.WriteLine($"HTML file {filename} saved successfully in your directory");
            }
            else
            {
                Console.WriteLine("No choices found in the API response");
            }
        }

        Console.WriteLine("HTML files generation completed.");

        // Generate a download link
        string zipFileName = "generated_html_files.zip";
        ZipFile.CreateFromDirectory(outputDirectory, zipFileName);
        Console.WriteLine($"HTML files have been zipped into {zipFileName}");
    }
}
