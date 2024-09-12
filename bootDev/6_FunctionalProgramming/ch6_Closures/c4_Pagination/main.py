from functools import reduce


def paginator(page_length):

    def paginate(document):
        def add_word_to_pages(pages, word):
            if len(word) == 0: 
                return pages
            if len(pages) == 0: 
                pages.append(word)
            else: 
                page = pages[-1]
                if len(page) + 1 + len(word) <= page_length: 
                    page += " " + word; 
                    pages[-1] = page
                else: 
                    pages.append(word)
            return pages
        doc_pages = []
        words = document.split(' ')
        for word in words: 
            add_word_to_pages(doc_pages, word)
        
        return doc_pages

    return paginate