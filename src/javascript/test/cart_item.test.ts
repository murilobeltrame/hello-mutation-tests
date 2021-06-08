import { Author } from "../src/domain/entities/author"
import { Book } from "../src/domain/entities/book"
import { CartItem } from "../src/domain/entities/cart_item"
import { Publisher } from "../src/domain/entities/publisher"

describe('Cart Item', () => {
    it(' should be instantiated', () => {
        const quantity = 1
        const price = 1
        const book = new Book({
            title: 'The Book',
            authors: [new Author({ firstName: 'Jhon', lastName: 'Doe' })],
            publisher: new Publisher({ name: 'The Publisher' })
        })
        book.setPrice(price)

        const cartItem = new CartItem({ book, price, quantity })

        expect(cartItem.book).toBe(book)
        expect(cartItem.price).toEqual(price)
        expect(cartItem.quantity).toEqual(quantity)
    })
})