import { Review } from '../src/domain/entities/review'

describe('Review', () => {
    it(' should be instantiated', () => {
        const rating = 1
        const note = 'Nothing important'

        const review = new Review({ rating, note })

        expect(review.rating).toEqual(rating)
        expect(review.note).toEqual(note)
    })
})