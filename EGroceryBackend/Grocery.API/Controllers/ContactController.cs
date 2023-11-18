using Grocery.Repo.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Mail;

[ApiController]
[Route("api/contact")]
public class ContactController : ControllerBase
{
    [HttpPost]
    public IActionResult PostFormData([FromBody] ContactUs formData)
    {
        // Validate the form data (you can add validation logic here)

        // Handle the form data (you can save it to the database, send email, etc.)
        // For example, you can log the form data for now
        Console.WriteLine($"Received form data - FirstName: {formData.FirstName},LastName: {formData.LastName}, Email: {formData.Email},Number: {formData.Number}, Message: {formData.Message}");

        // Send email to the admin
        SendEmailToAdmin(formData);

        // You can return a success response to the client
        return Ok(new { Message = "Form data received successfully!" });
    }

    private void SendEmailToAdmin(ContactUs formData)
    {
        string adminEmail = ""; // Replace with the admin's email address
        string smtpServer = "smtp.gmail.com"; // Replace with your SMTP server address
        int smtpPort = 587; // Replace with your SMTP server port
        string smtpUsername = "";
        string smtpPassword = "";

        using (SmtpClient client = new SmtpClient(smtpServer, smtpPort))
        {
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
            client.EnableSsl = true;

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(adminEmail);
            mailMessage.To.Add(adminEmail);
            mailMessage.Subject = "New Contact Form Submission";
            mailMessage.Body = $"FirstName: {formData.FirstName}\nLastName: {formData.LastName}\nEmail: {formData.Email}\nNumber: {formData.Number}\nMessage: {formData.Message}";

            try
            {
                client.Send(mailMessage);
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, etc.
                Console.WriteLine($"Failed to send email: {ex.Message}");
            }
        }
    }
}
