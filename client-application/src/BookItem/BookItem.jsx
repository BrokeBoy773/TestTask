import React from 'react';
import Classes from './BookItem.module.css';
import { BookService } from '../BookService/BookService';
import { SquareButton } from '../SquareButton/SquareButton';

export const BookItem = ({book, fetchBookList}) => {
    const handleDeleteBook = async () => {
        await BookService.deleteBookAsync(book.id);
        fetchBookList(null);
    };

  return (
    <div className={Classes.container}>
        <div>
            {book.title.title}
        </div>

        <SquareButton onClick={handleDeleteBook}>
            Удалить
        </SquareButton>
    </div>
  );
}
