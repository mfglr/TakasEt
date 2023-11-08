export interface LoginResponse{
  accessToken : string;
  expirationDateOfAccessToken : Date;
  refreshToken : string;
  expirationDateOfRefreshToken : Date;
  id : string;
  userName : string;
  email : string;
}
