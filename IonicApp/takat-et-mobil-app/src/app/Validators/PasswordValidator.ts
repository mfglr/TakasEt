import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";

const minLengthErrorMessage = "The password must be greater than or equal 9 character!";
const upperCaseErrorMessage = "The password must contain an uppercase!";
const lowerCaseErrorMessage = "The password must contain an lowercase!";
const alphaNumericErrorMessage = "The password must contain an alpha numeric character (. + _ ; ...)!";

function isDigit(c : string) : boolean{
  return c.charCodeAt(0) >= 48 && c.charCodeAt(0) <= 57
}
function hasDigit(s : string | null) : boolean{
  if(s == null) return false;
  for(var i = 0; i < s.length;i++)
    if(isDigit(s[i]))
      return true;
  return false;
}

function isUpperCase(c : string) : boolean{
  return c.charCodeAt(0) >= 65 && c.charCodeAt(0) <= 90
}
function hasUpperCase(s : string | null) : boolean{
  if(s == null) return false;
  for(var i = 0; i < s.length;i++)
    if(isUpperCase(s[i]))
      return true;
  return false;
}

function isLowerCase(c : string) : boolean{
  return c.charCodeAt(0) >= 97 && c.charCodeAt(0) <= 122
}
function hasLowerCase(s : string | null) : boolean{
  if(s == null) return false;
  for(var i = 0; i < s.length;i++)
    if(isLowerCase(s[i]))
      return true;
  return false;
}

function isAlphaNumeric(c : string) : boolean{
  return c.charCodeAt(0) >= 32 && c.charCodeAt(0) <= 47 ||
         c.charCodeAt(0) >= 58 && c.charCodeAt(0) <= 64 ||
         c.charCodeAt(0) >= 91 && c.charCodeAt(0) <= 96 ||
         c.charCodeAt(0) >= 123 && c.charCodeAt(0) <= 126
}
function hasAlphaNumeric(s : string | null) : boolean{
  if(s == null) return false;
  for(var i = 0; i < s.length;i++)
    if(isAlphaNumeric(s[i]))
      return true;
  return false;
}

export function passwordValidator(
  minLength : number = 9,
  upperCase : boolean = false,
  lowerCase : boolean = false,
  alphaNumeric : boolean = false,
  digit : boolean = false
) : ValidatorFn {

  return (control : AbstractControl<string | null>) : ValidationErrors | null => {
    let r : ValidationErrors = {};
    let isError = false;

    if(control.value == null || control.value.length < minLength){
      r["minLength"] = minLengthErrorMessage
      isError = true;
    }

    if(upperCase){
      if(!hasUpperCase(control.value)){
        r["upperCase"] = upperCaseErrorMessage;
        isError = true;
      }
    }

    if(lowerCase){
      if(!hasLowerCase(control.value)){
        r["lowerCase"] = lowerCaseErrorMessage;
        isError = true;
      }
    }

    if(alphaNumeric){
      if(!hasAlphaNumeric){
        r["alphaNumeric"] = alphaNumericErrorMessage
        isError = true;
      }
    }

    if(digit){
      if(!hasDigit){
        r["digit"] = digit;
        isError = true;
      }
    }

    if(isError) return r;
    return null;
  }


}
