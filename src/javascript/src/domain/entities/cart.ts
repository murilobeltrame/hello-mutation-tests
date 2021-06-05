import { ArgumentError } from "../errors/argument_error";
import { ArgumentNullError } from "../errors/argument_null_error";
import { Book } from "./book";
import { CartItem } from "./cart_item";

export class Cart {
    
    public createdAt!: Date;
    public sessionId!: string;
    
    private _items!: CartItem[];
    public get items(): CartItem[] { return this._items; }

    private _checkedOut!: boolean;
    public get checkedOut(): boolean {return this._checkedOut;}

    public get totalValue(): number {
        let value = 0;
        this._items.forEach((item) => value += item.price * item.quantity);
        return value;
    }

    constructor(init: Partial<Cart>) {
        Object.assign(this, init)
        this._items = []
        this._checkedOut = false
    }

    addItem(book: Book, quantity: number): void {
        if (!book) throw new ArgumentNullError('book')
        const item = this.getCartItemByTitle(book.title)
        if (item) {
            const index = this._items.indexOf(item)
            this._items[index] = new CartItem({
                book: item.book, 
                quantity: item.quantity + quantity
            })
            return
        }
        this._items.push(new CartItem({book, quantity}))
    }

    checkout(): void { this._checkedOut = true }

    removeItem(bookTitle: string): void {
        if (!bookTitle) throw new ArgumentNullError('bookTitle')
        const item = this.getCartItemByTitle(bookTitle)
        if (!item) throw new ArgumentError('bookTitle')
        this._items.splice(this._items.indexOf(item), 1)
    }

    updateItemQuantity(bookTitle: string, newQuantity: number): void {
        if (!bookTitle) throw new ArgumentNullError('bookTitle')
        const item = this.getCartItemByTitle(bookTitle)
        if (!item) throw new ArgumentError('bookTitle')
        const index = this._items.indexOf(item)
        this._items[index] = new CartItem({
            book: item.book, 
            quantity: newQuantity
        })
    }

    private getCartItemByTitle(title: string): CartItem | null {
        const item = this._items.find((item) => item.book.title === title)
        return item ?? null
    }
}