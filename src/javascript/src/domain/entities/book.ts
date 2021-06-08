import { ArgumentNullError } from '../errors/argument_null_error'
import { Author } from './author'
import { Price } from './price'
import { Publisher } from './publisher'
import { Review } from './review'

export class Book {
    
    public authors!: Author[]
    public publisher!: Publisher
    public title!: string
    public pages?: number

    private _reviews: Review[]
    public get reviews() { return this._reviews }

    private _pricing: Price[]
    public get pricing() { return this._pricing }

    constructor(init: Partial<Book>) {
        if (!init.title) throw new ArgumentNullError('title')
        if (!init.publisher) throw new ArgumentNullError('publisher')
        if (!(init.authors?.length ?? 0)) throw new ArgumentNullError('authors')
        Object.assign(this, init)

        this._reviews = []
        this._pricing = []
    }

    setPrice(value: number, startingAt?: Date): void {
        this._pricing.push(new Price({
            value, 
            startingAt: startingAt ?? new Date()
        }))
    }

    getPriceAt(date: Date): Price | null {
        return this._pricing
            .sort((a, b) => a.startingAt >= b.startingAt ? 1 : -1)
            .find((price) => price.startingAt <= date) ?? null
    }

    placeReview(rating: number, note?: string): void {
        this._reviews.push(new Review({rating, note}))
    }

    getAverageRating(): number | null {
        if (this._reviews?.length ?? 0) return null
        let avg = 0
        this._reviews?.forEach((review) => avg += review.rating)
        return avg / this._reviews.length
    }
}