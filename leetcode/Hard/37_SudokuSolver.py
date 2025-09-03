import pytest 
from typing import List, Callable, Any

class Solution:
    def solveSudoku(self, board: List[List[str]]) -> None:
        """
        Do not return anything, modify board in-place instead.
        """

class SudokuCell:
    def __init__(self, value: int = 0):
        self.possible_values = [n for n in range(1, 10)]
        self._value = value
        if value > 0: 
            self.set_value(value)
        self.value_set = Event()

    def set_value(self, value: int) -> None: 
        if value > 0 and value < 10: 
            self._value = value
            self.value_set.fire(value)
            self.possible_values.clear() 
            self.possible_values.append(value)

    def exclude_value(self, value: int) -> None: 
        if value in self.possible_values: 
            self.possible_values.remove(value)

class SudokuBoard: 
    def __init__(self): 
        self._board = [[SudokuCell() for _ in range(9)] for _ in range(9)]
        self._wire_horizontal_events()
        self._wire_vertical_events()

    def set_value(self, row: int, col: int, val:int): 
        self._board[row][col].set_value(val)

    def get_value(self, row: int, col: int) -> int: 
        return self._board[row][col]._value

    @staticmethod
    def parse(values: List[List[str]]) -> "SudokuBoard": 
        board = SudokuBoard()
        for row in range(9): 
            for col in range(9): 
                if values[row][col] != "": 
                    board.set_value(row, col, int(values[row][col]))
        return board

    """
    Every cell in a row will subscribe to the value changed event for 
    all the other cells
    """
    def _wire_horizontal_events(self): 
        start_col = 0
        end_col = 8

        for row in range(0, 9): 
            self._wire_events(row, row, start_col, end_col)
        """
        for row in range(9): 
            for cell in range(9):
                subscriber = self._board[row][cell] 
                for col in range(9): 
                    if col == cell: 
                        continue
                    emitter = self._board[row][col]
                    emitter.value_set.subscribe(subscriber.exclude_value)
        """

    """
    Every cell in a col will subscribe to the value changed event for all the
    other cells
    """
    def _wire_vertical_events(self): 
        start_row = 0
        end_row = 8
        for col in range(0, 9): 
            self._wire_events(start_row, end_row, col, col)

    """
            Zones of 9 (3X3): 
            _____________
            | 1 | 2 | 3 |
            |____________
            | 4 | 5 | 6 |
            |____________
            | 7 | 8 | 9 |
            |____________

    """

    """
    Every cell in range will subscribe to the value changed event for 
    all the other cells
    """
    def _wire_events(self, start_row: int, end_row: int, start_col: int, end_col: int): 
        
        cells = [] 
        for row in range(start_row, end_row + 1): 
            for col in range(start_col, end_col + 1): 
                cells.append((row, col))

        for cell_row, cell_col in cells: 
            for row in range(start_row, end_row + 1): 
                for col in range(start_col, end_col + 1): 
                    if row == cell_row and col == cell_col: 
                        continue
                    subscriber = self._board[cell_row][cell_col] 
                        
                    emitter = self._board[row][col]
                    emitter.value_set.subscribe(subscriber.exclude_value)
    


class Event: 
    def __init__(self):
        self._subscribers: list[Callable[..., Any]] = []

    def subscribe(self, fn: Callable[..., Any]) -> None:
        self._subscribers.append(fn)

    def unsubscribe(self, fn: Callable[..., Any]) -> None:
        self._subscribers.remove(fn)

    def fire(self, *args, **kwargs) -> None:
        for fn in self._subscribers:
            fn(*args, **kwargs)


if __name__ == "__main__": 
    pytest.main([__file__])


"""
from typing import Callable, Any

class Event:
    def __init__(self):
        self._subscribers: list[Callable[..., Any]] = []

    def subscribe(self, fn: Callable[..., Any]) -> None:
        self._subscribers.append(fn)

    def unsubscribe(self, fn: Callable[..., Any]) -> None:
        self._subscribers.remove(fn)

    def fire(self, *args, **kwargs) -> None:
        for fn in self._subscribers:
            fn(*args, **kwargs)


class Button:
    def __init__(self, label: str):
        self.label = label
        self.clicked = Event()

    def click(self):
        print(f"{self.label} clicked")
        self.clicked.fire(self.label)


# Usage
def on_button_click(label: str):
    print(f"Button {label} was clicked!")

btn = Button("OK")
btn.clicked.subscribe(on_button_click)
btn.click()
"""

def test_board_setup_smoke_test(): 
    board = SudokuBoard()
    
    # board should have 9 rows and 9 cols
    assert(len(board._board) == 9)
    assert(len(board._board[0]) == 9)
    assert(len(board._board[0][0].possible_values) == 9)

    # set the value of 1st cell...
    board.set_value(0, 0, 3)
    assert(board.get_value(0, 0) == 3)
    assert(board.get_value(0, 1) == 0)

    # cells in the 1st row should have removed 3 as a possible value
    assert((3 not in board._board[0][1].possible_values))
    assert((3 not in board._board[0][8].possible_values))
    
    # cell in the second row in last col should have 3 as a possible value
    assert(3 in board._board[1][8].possible_values)

    # cells in the 1st column should have removed 3 as a possible value
    assert((3 not in board._board[1][0].possible_values))
    assert((3 not in board._board[8][0].possible_values))

    # first cell should have only one possible value: 3
    assert(len(board._board[0][0].possible_values) == 1)
    assert(board._board[0][0].possible_values[0] == 3)

if __name__ == "__main__":
    pytest.main([__file__]) 
