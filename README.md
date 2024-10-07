Aquí tienes el contenido formateado correctamente para un archivo `README.md`, utilizando Markdown para diferenciar los títulos, bloques de código y demás elementos:

```md
# Hotel Reservation API with JWT Authentication

This API, built with .NET 8, provides a set of endpoints to efficiently manage hotel reservations. It includes JWT-based authentication, allowing secure access for employees who manage guest reservations and room availability. The API integrates with a MySQL database and uses environment variables for configuration.

## Key Features

- **Room and Reservation Management**: CRUD operations (Create, Read, Update, Delete) for rooms, reservations, and guests.
- **JWT Authentication and Authorization**: Secure endpoints accessible only to authenticated users.
- **Room Availability**: Endpoints to check available rooms and room types.
- **Swagger Integration**: Fully documented API with Swagger for easy exploration and testing.
- **Seed Data**: Predefined room types and rooms loaded into the database on application startup.

## Project Requirements

- **.NET 8 SDK** or higher.
- **MySQL Database**.
- **Swagger** integrated to explore the API without external tools like Postman.

## Environment Variables

Make sure to configure the following environment variables before running the application:

```bash
DB_HOST=your_host
DB_NAME=your_database_name
DB_PORT=your_port
DB_USERNAME=your_username
DB_PASSWORD=your_password

JWT_KEY=your_jwt_secret
JWT_ISSUER=your_jwt_issuer
JWT_AUDIENCE=your_jwt_audience
JWT_EXPIRES_IN=expiration_time_in_minutes
```

## Project Setup

### 1. Clone the Repository:

```bash
git clone https://github.com/OscarCalle0/PruebaNET_Hotel.git
cd PruebaNET_Hotel
```

### 2. Restore NuGet Packages

Run the following command to restore the necessary packages:

```bash
dotnet restore
```

### 3. Configure Environment Variables

Make sure the environment variables for the database and JWT are set as described above.

### 4. Apply Database Migrations

Apply the migrations to configure the database schema:

```bash
dotnet ef database update
```

### 5. Run the API

Start the API with the following command:

```bash
dotnet run
```

## Accessing the Swagger Interface

After running the API, Swagger will be available at:

- [https://localhost:5001/swagger](https://localhost:5002/swagger)

These allow you to explore and test the API.

## JWT Authentication

To access the protected endpoints, you must first authenticate by sending a `POST` request to `/api/v1/auth/login` with valid credentials. The server will return a JWT token that must be included in the headers of subsequent requests.

### Example login request:

```http
POST /api/v1/auth/login HTTP/1.1
Host: localhost:5000
Content-Type: application/json

{
  "email": "your_email@example.com",
  "password": "your_password"
}
```

Once authenticated, include the JWT token in the `Authorization` header for requests to protected endpoints:

```http
GET /api/v1/reservations HTTP/1.1
Host: localhost:5000
Authorization: Bearer {your-jwt-token}
```

## API Endpoints

### Unprotected Endpoints (No Authentication Required)

- `POST /api/v1/auth/login`: Employee login and obtain a JWT token.
- `GET /api/v1/rooms/available`: Get available rooms for reservation.
- `GET /api/v1/room_types`: Get all available room types.
- `GET /api/v1/room_types/{id}`: Get details of a specific room type.
- `GET /api/v1/rooms/status`: Get a summary of room status (occupied vs available).
- `POST /api/v1/guest`: Register a guest in the system.

### Protected Endpoints (JWT Authentication Required)

- `GET /api/v1/bookings/search/{identification_number}`: Search guest reservations by identification number.
- `GET /api/v1/bookings/{id}`: Get details of a specific reservation.
- `POST /api/v1/bookings`: Create a new reservation for a guest.
- `DELETE /api/v1/bookings/{id}`: Delete a specific reservation.
- `GET /api/v1/rooms`: Get a list of all hotel rooms.
- `GET /api/v1/rooms/{id}`: Get details of a specific room.
- `GET /api/v1/guests`: Get a list of all registered guests in the system.
- `GET /api/v1/guests/{id}`: Get details of a specific guest.
- `DELETE /api/v1/guests/{id}`: Delete a specific guest from the system.
- `GET /api/v1/guests/search/{keyword}`: Search guests using a keyword.
- `PUT /api/v1/guests/{id}`: Update a guest’s personal information.
- `GET /api/v1/rooms/occupied`: Get the rooms that are currently occupied.

## Technologies Used

- **ASP.NET Core 8**
- **Entity Framework Core**
- **JWT (JSON Web Tokens) for Authentication**
- **MySQL Database**
- **Swagger for API Documentation**

## Seed Data

The following predefined room types are loaded into the database on application startup:

1. **Single Room**: Basic room with one single bed for solo travelers, priced at $50 per night.
2. **Double Room**: Flexible room with two single beds or one double bed, priced at $80 per night.
3. **Suite**: Luxurious room with a king-size bed and living area, priced at $150 per night.
4. **Family Room**: Spacious room with multiple beds, ideal for families, priced at $200 per night.

The hotel consists of 5 floors, with 10 rooms per floor, for a total of 50 rooms.

## Contributing Guide

If you wish to contribute to this project, follow the setup instructions described above and submit a pull request with your changes.

