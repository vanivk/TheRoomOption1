# TheRoomOption1
## Steps to Run the application
- Open solution in Visual Studio 2019 (.net 5 should be supported)
- Launch Update-Database command on Data project
- Build & Start PromoCodeService project
- App will be available on https://localhost:5001
- Acquire new JWT token via api/auth/login request with { "username": "test_user@optionone.com", "password": "Password12345"}
- Use this token for consequent requests. TTL of the token is 15 minutes by default, the new one can be obtained via api/auth/refresh endpoint (using cookie)
- Service and Promocodes support pagination and sorting with pageSize, page, sortDir, sort query parameters
