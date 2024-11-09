import axios from "axios";

export class BookService {
    static async getAllBooksAsync(searchString){
        if (searchString === null){
            const response = await axios.get(`https://localhost:7273/api/books`);
            return response;
        }
        
        const response = await axios.get(`https://localhost:7273/api/books?searchString=${searchString}`);
        return response;
    }

    static async createBookAsync(title) {
        await axios.post(`https://localhost:7273/api/books`, title);
    }

    static async deleteBookAsync(id) {
        await axios.delete(`https://localhost:7273/api/books/${id}`);
    }
}