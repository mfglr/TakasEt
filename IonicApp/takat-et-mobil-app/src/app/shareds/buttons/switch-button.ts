import { Observable, Subject, debounceTime, filter, map } from "rxjs";

export class SwitchButton{

  private _commitValue : Observable<boolean>
  private _valueChanges : Subject<boolean>

  private currentValue : boolean;
  private lastComittedValue : boolean;

  constructor(private initialValue : boolean,time : number) {
    this.lastComittedValue = initialValue;
    this.currentValue = initialValue;
    this._valueChanges = new Subject<boolean>();

    this._commitValue = this._valueChanges.pipe(
      debounceTime(time),
      filter(value => value != this.lastComittedValue),
      map(value => {this.lastComittedValue = value; return value;})
    )
  }

  public get commitValue() : Observable<boolean>{
    return this._commitValue
  }

  public get valueChanges() : Observable<boolean>{
    return this._valueChanges
  }

  switch(){
    this.currentValue = !this.currentValue
    this._valueChanges.next(this.currentValue);
  }

}


