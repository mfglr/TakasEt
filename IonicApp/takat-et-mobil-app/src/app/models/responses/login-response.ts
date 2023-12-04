export interface LoginResponse{
  userId : number;
  accessToken : string;
  expirationDateOfAccessToken : Date;
  refreshToken : string;
  expirationDateOfRefreshToken : Date;
}
