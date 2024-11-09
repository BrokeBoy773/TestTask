import "./styles/GeneralStyles.css";
import { useEffect, useState } from "react";
import { BookService } from "./BookService/BookService";
import { BookBox } from "./BookBox/BookBox";

function App() {
  const [bookList, setBookList] = useState();

  const fetchBookList = async (searchString) => {
    const response = await BookService.getAllBooksAsync(searchString);
    setBookList(response.data);
  }

  useEffect(() => {
    fetchBookList(null);
  }, []);

  if (bookList){
    return (
      <div className="app">
        <BookBox bookList={bookList} fetchBookList={fetchBookList} />
      </div>
    );
  }
}

export default App;