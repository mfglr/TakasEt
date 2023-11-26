export interface LoginResponse{
  accessToken : string;
  expirationDateOfAccessToken : Date;
  refreshToken : string;
  expirationDateOfRefreshToken : Date;
  id : number;
  userName : string;
  email : string;
}
