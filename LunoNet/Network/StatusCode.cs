namespace LunoNet.Network
{
    public enum StatusCode
    {
        Ok = 200,
        Created = 201,
        Accepted = 202,
        BadRequest = 400,
        UnAuthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        Confilct = 409,
        LimitExceeded = 429,
        InternalServerError = 500,
        BadGateway = 501
    }
}
