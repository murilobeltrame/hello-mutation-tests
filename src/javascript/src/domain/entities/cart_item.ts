import { Book } from './book'

export class CartItem {
    private _book!: Book
    public get book(): Book {return this._book}

    private _price!: number
    public get price(): number {return this._price}

    private _quantity!: number
    public get quantity(): number {return this._quantity}

    constructor(init: Partial<CartItem>) {
        this._book = init.book!
        this._quantity = init.quantity!
        this._price = init.book!.getPriceAt(new Date())!.value ?? 0
    }
}