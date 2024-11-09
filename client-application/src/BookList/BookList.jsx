import React from 'react';
import { BookItem } from '../BookItem/BookItem';

export const BookList = ({bookList, fetchBookList}) => {
  return (
    <div>
        {bookList.map(book => 
            <BookItem key={book.id} book={book} fetchBookList={fetchBookList} />
        )}
    </div>
  );
}
