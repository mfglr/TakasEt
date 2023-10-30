export class GenericMode<T>{

  constructor(behaviour : "circular" | "linear", data : T[] | null | undefined) {
    this._mode = data ? data.length : 0;
    this._currentIndex = 0;
    this._data = data;
    this._behaviour = behaviour;
  }
  private _behaviour : "circular" | "linear";
  private _currentIndex : number = 0;
  private _mode : number;
  private _data : T[] | null | undefined;

  get currentIndex() : number{
    return this._currentIndex;
  }
  anyData() : boolean{
    return this._mode != 0;
  }

  prev() : T | null{
    if(!this.anyData()) return null
    if(this._behaviour == "circular")
      this._currentIndex = (this._currentIndex + this._mode - 1) % this._mode;
    else{
      if(this._currentIndex > 0)
        this._currentIndex = this._currentIndex - 1;
    }
    return this._data![this._currentIndex];
  }

  next() : T | null{
    if(!this.anyData()) return null
    if(this._behaviour == "circular")
      this._currentIndex = (this._currentIndex + 1) % this._mode;
    else{
      if(this._currentIndex < this._data!.length - 1)
        this._currentIndex = this._currentIndex + 1;
    }
    return this._data![this._currentIndex];
  }

  current() : T | null{
    if(!this.anyData()) return null
    return this._data![this._currentIndex];
  }

  isLastIndex(): boolean {
    return this._currentIndex == (this._mode - 1);
  }

  isFirstIndex(): boolean {
    return this._currentIndex == 0;
  }

  addItem( item : T){
    if(this.anyData())
      this._data = [...this._data!,item];
    else this._data = [item];
  }
}
