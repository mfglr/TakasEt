export class GenericMode<T>{

  constructor(data? : T[] | null) {
    this._mode = data ? data.length : 0;
    this._data = data;
  }

  private _curruntIndex : number = 0;
  private _mode : number;
  private _data : T[] | null | undefined;

  get currentIndex() : number{
    return this._curruntIndex;
  }
  anyData() : boolean{
    return this._mode != 0;
  }

  prev() : T | null{
    if(!this.anyData()) return null
    this._curruntIndex = (this._curruntIndex + this._mode - 1) % this._mode;
    return this._data![this._curruntIndex];
  }

  next() : T | null{
    if(!this.anyData()) return null
    this._curruntIndex = (this._curruntIndex + 1) % this._mode;
    return this._data![this._curruntIndex];
  }

  current() : T | null{
    if(!this.anyData()) return null
    return this._data![this._curruntIndex];
  }

  isLastIndex(): boolean {
    return this._curruntIndex == (this._mode - 1);
  }

  isFirstIndex(): boolean {
    return this._curruntIndex == 0;
  }
}
