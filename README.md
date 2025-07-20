# AuditTrailAPI

A .NET Core Web API to track and log changes for auditing purposes.

## 🚀 Features

- Records create/update/delete operations
- Captures before and after data changes
- User ID tracking for all actions
- JSON API with Swagger UI support

## 🧰 Technologies Used

- ASP.NET Core
- Entity Framework Core
- Swagger (Swashbuckle)

- Request body:

{
  "entityName": "User",
  "actionType": 0,
  "userId": "Vipin123",
  "beforeChange": null,
  "afterChange": {
    "Id": 1001,
    "Name": "vipin",
    "Email": "vipin@example.com"
  }
}

Response part:
	
{
  "entityName": "User",
  "actionType": 0,
  "userId": "Vipin123",
  "timestamp": "2025-07-20T14:17:31.7138359Z",
  "changedColumns": {
    "Id": {
      "item1": null,
      "item2": "1001"
    },
    "Name": {
      "item1": null,
      "item2": "vipin"
    },
    "Email": {
      "item1": null,
      "item2": "vipin@example.com"
    }
  }
}



