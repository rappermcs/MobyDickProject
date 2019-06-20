# MobyDickProject
Park-net

## coding challenge: count words in Moby Dick

the book "Moby Dick" 
by Herman Melville
describes an epic battle of a gloomy captain against his personal nemesis, 
the white whale. 

you can find the full text 
for Herman Melville’s “Moby Dick”
as a **text file**
on www.gutenberg.org. 

---

# first;
write a c# console application,
that "downloads the text file"
and then counts how often each word occurs in the book 
and save the result in an xml file.

xml structure should be like this.

<words>
  <word text="word1" count="123" />
  <word text="word2" count="235" />
</words>

---

# second;
write an asp.net mvc web application,
that shows the top 10 max words in /Word/List view as an html table,
by reading the xml.

write unit tests for criticals methods,
and also please cache the reading xml file action.

good luck
