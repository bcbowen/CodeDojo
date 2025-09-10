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