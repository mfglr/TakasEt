export interface LoginResponse{
    accessToken? : string;
    expirationDateOfAccessToken? : Date;
    refreshToken? : string;
    expirationDateOfRefreshToken? : Date;
}