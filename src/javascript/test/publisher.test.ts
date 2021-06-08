import { Publisher } from '../src/domain/entities/publisher'

describe('Publisher', () => {
    it(' should be instantiated', () => {
        const name = 'The publisher'

        const publisher = new Publisher({name})

        expect(publisher.name).toEqual(name)
    })
})