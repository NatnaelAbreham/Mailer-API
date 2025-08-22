# Mailer API

**Mailer API** is a lightweight email-sending service built with **ASP.NET Core**.  
It allows users to send emails via a simple API route while gracefully handling errors and providing meaningful HTTP status codes.

---

## Features

- Send emails using **SMTP** (e.g., Gmail)  
- Graceful error handling for:  
  - Network issues  
  - Server downtime  
  - Authentication failures  
- Returns clear **HTTP status codes** and messages  
- Easy to integrate with any frontend or application  
- Supports **HTML email content**

---

## Gmail App Password Setup

1. Go to your **Google Account → Security**  
2. Enable **2-Step Verification** if it’s not already on  
3. In the **Security** section, search for **“App Passwords”**  
4. Click **App Passwords**, select **Mail** as the app, and choose **Other (Custom name)** for the device  
5. Enter a name (e.g., `ASP.NET Mailer`) and click **Generate**  
6. Google will generate a **16-character App Password**  
7. Use this **generated password** in your `appsettings.json` instead of your Gmail password  

---

## API Usage Example

**Endpoint:**  
POST http://localhost:5000/api/mail/send


**Request Body (JSON):**
```json
{
  "toEmail": "example@gmail.com",
  "subject": "Hello from API",
  "body": "<h1>Welcome!</h1><p>This is a test email from ASP.NET Core API.</p>"
}
```
Response (Success):
{
  "StatusCode": 200,
  "Message": "Email sent successfully!"
}

Possible Error Responses:

400 Bad Request – SMTP command error (e.g., invalid recipient)

401 Unauthorized – Authentication failure (wrong username or App Password)

503 Service Unavailable – Network or server issue

500 Internal Server Error – Other unexpected errors
