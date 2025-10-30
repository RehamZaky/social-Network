🌐 Social Network Site

A modern social networking platform built with .NET Core, featuring user interaction, posts, comments, groups, and media sharing — designed with scalability, clean architecture, and modularity in mind.

🚀 Features

✅ User Management

Registration, login, and profile management

Password encryption & JWT authentication

✅ Posts & Media

Create, edit, delete posts

Attach photos, videos, and files

Like and comment system

✅ Groups & Pages

Create and manage groups and pages

Add members, share group posts, and moderate content

✅ Friends & Followers

Send/accept friend requests

Follow/unfollow users

✅ Hashtags & Search

Tag posts with hashtags

Search users, groups, and posts by keyword or tag


🧱 Architecture

This project follows Clean Architecture and the Repository + Unit of Work pattern.

SocialNetwork/
├── Social.API/                 # ASP.NET Core Web API
├── Social.Application/         # Business logic & services
├── Social.Domain/              # Entities and DTOs
├── Social.Infrastructure/      # Data access & repositories
└── Social.Tests/               # Unit and integration tests
