export class Review {
    private _rating!: number
    public get rating(): number {return this._rating}

    private _note!: string
    public get note(): string {return this._note}

    constructor(init: Partial<Review>) {
        this._note = init.note!
        this._rating = init.rating!
    }
}