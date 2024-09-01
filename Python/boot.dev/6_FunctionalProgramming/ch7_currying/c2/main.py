def create_markdown_image(alt_text):
    # ![alt text](url "title")
    text = f"![{alt_text}]"
    def create_link(url): 
        nonlocal text
        escaped_url = url.replace('(', '%28').replace(')', '%29')

        link = f"{text}({escaped_url})"
        def set_title(title = None): 
            nonlocal link
            if title != None and title != '': 
                link = link.replace(')', '')
                link = f'{link} "{title}")'
            return link
        return set_title
    return create_link