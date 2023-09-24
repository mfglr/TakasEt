export class Mode{

  constructor(mode : number) { this._mode = mode; }
  private _curruntIndex : number = 0;
  private _mode : number;

  public get currentIndex() : number { return this._curruntIndex; }

  public prev() : void {
    this._curruntIndex = (this._curruntIndex + this._mode - 1) % this._mode;
  }

  public next() : void {
    this._curruntIndex = (this._curruntIndex + 1) % this._mode;
  }

  public isLastIndex(): boolean {
    return this._curruntIndex == (this._mode - 1);
  }

  public isFirstIndex(): boolean {
    return this._curruntIndex == 0;
  }
}
