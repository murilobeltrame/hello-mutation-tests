import { Price } from '../src/domain/entities/price';

describe('Price', () => {
    it(' should be instantiated', () => {
        const value = 1
        const startingAt = new Date()

        const price = new Price({ value, startingAt })

        expect(price.value).toEqual(value)
        expect(price.startingAt).toEqual(startingAt)
    })
})