export class Price {
    private _value!: number
    public get value(): number {return this._value}

    private _startingAt!: Date
    public get startingAt(): Date {return this._startingAt}

    constructor(init: Partial<Price>) {
        this._value = init.value!
        this._startingAt = init.startingAt!
    }
}