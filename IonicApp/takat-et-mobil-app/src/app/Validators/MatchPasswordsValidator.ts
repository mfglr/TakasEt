import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";

export function matchPasswordsValidator() : ValidatorFn {
  return (control : AbstractControl) : ValidationErrors | null => {
    var password = control.get("password")?.value
    var confirmPassword = control.get("confirmPassword")?.value

    if(password != confirmPassword)
      return {"notmatch" : "it does not match password!" }
    return null;
  }
}
