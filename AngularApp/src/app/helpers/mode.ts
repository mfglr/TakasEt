export class Mode{

  constructor(mode : number,currentIndex? : number) {
    this._mode = mode;
    if(currentIndex) this._currentIndex = currentIndex;
  }

  private _currentIndex : number = 0;
  private _mode : number;

  public get currentIndex() : number { return this._currentIndex; }

  public prev() : number {
    this._currentIndex = (this._currentIndex + this._mode - 1) % this._mode;
    return this._currentIndex;
  }

  public next() : number {
    this._currentIndex = (this._currentIndex + 1) % this._mode;
    return this._currentIndex;
  }

  public isLastIndex(): boolean {
    return this._currentIndex == (this._mode - 1);
  }

  public isFirstIndex(): boolean {
    return this._currentIndex == 0;
  }
}
