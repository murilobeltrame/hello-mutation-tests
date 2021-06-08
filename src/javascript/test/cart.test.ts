import { Cart } from '../src/domain/entities/cart'

describe('Cart', () => {
    it(' should be instantiated', () => {
        const sessionId = '1'
        const createdAt = new Date()

        const cart = new Cart({ sessionId, createdAt })

        expect(cart.sessionId).toEqual(sessionId)
        expect(cart.createdAt).toEqual(createdAt)
    })
})