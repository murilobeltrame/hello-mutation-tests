import { Author } from "../src/domain/entities/author"
import { Book } from "../src/domain/entities/book"
import { Publisher } from "../src/domain/entities/publisher"

describe('Book', () => {
    it(' should be instantiated', () => {
        const title = 'The Book'
        const authorFirstName = 'Jhon'
        const authorLastName = 'Doe'
        const publisherName = 'The Publisher'

        const book = new Book({
            authors: [new Author({firstName: authorFirstName, lastName: authorLastName})],
            publisher: new Publisher({name: publisherName}),
            title
        })

        expect(book.title).toEqual(title)
        expect(book.publisher.name).toEqual(publisherName)
        expect(book.authors).toHaveLength(1)
    })
})