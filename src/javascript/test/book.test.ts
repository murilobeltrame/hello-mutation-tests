import { Author } from '../src/domain/entities/author'
import { Book } from '../src/domain/entities/book'
import { Publisher } from '../src/domain/entities/publisher'
import { ArgumentNullError } from '../src/domain/errors/argument_null_error'

describe('Book', () => {

    const validTitle = 'Book Title'
    const mockedAuthors = [new Author({ firstName: 'Jhon', lastName: 'Doe' })]
    const mockedPublisher = new Publisher({ name: 'Publishers House' })

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

    it(' created without title should throw an ArgumentNullError', () => {
        const act = () => {
            new Book({ authors: mockedAuthors, publisher: mockedPublisher })
        }
        expect(act).toThrow(ArgumentNullError)
    })
})