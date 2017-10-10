# Configuration
```
bin/elasticsearch-plugin.bat install analysis-ph

PUT /people_ph
{
  "settings": {
    "analysis": {
      "filter": {
        "dbl_metaphone": {
          "type":    "phonetic",
          "encoder": "double_metaphone"
        }
      },
      "analyzer": {
        "dbl_metaphone": {
          "tokenizer": "standard",
          "filter":    "dbl_metaphone"
        }
      }
    }
  }
}


PUT REQUEST /people_ph/_mappings/entities
{
  "properties": {
    "name": {
      "type": "text",
      "fields": {
        "phonetic": {
          "type":     "text",
          "type":     "text",
          "analyzer": "dbl_metaphone"
        }
      }
    }
  }
}


PUT REQUEST  /{index}/_settings
{
  "max_result_window" : 500000
}
```

# API
```
GET /search/query/smart
 args:
    name: str (phonetic searching)
    full: str (without name and fuzzy search with 1 edit distance)

GET /serach/query
 args:
    query: str

    full text search with auto edit distance: length <= 2 distance = 0, 2 < length <= 5 distance = 1,
    5 < length distance = 2
```


# [Basic Concepts:](https://www.elastic.co/guide/en/elasticsearch/reference/current/_basic_concepts.html)

#### [Intro to Elasticsearch](https://www.slideshare.net/omnisis/intro-to-elasticsearch)

1.	Cluster
2.	Node
3.	Index
4.	Type
5.	Document
6.	Shards & Replicas

#### [Searching—The Basic Tools:](https://www.elastic.co/guide/en/elasticsearch/guide/current/search.html)

1.	**Mapping** - How the data in each field is interpreted
2.	**Analysis** - How full text is processed to make it searchable
3.	**Query DSL** - The flexible, powerful query language used by Elasticsearch

#### [Analysis and Analyzerse:](https://www.elastic.co/guide/en/elasticsearch/guide/current/analysis-intro.html)

1.  Character filters
2.  Tokenizer
3.  Token filters

#### [Built-in Analyzerse:](https://www.elastic.co/guide/en/elasticsearch/guide/current/analysis-intro.html#_built_in_analyzers)

1. Standard analyzer
2. Simple analyzer
3. Whitespace analyzer
4. Language analyzers


#### [Document Metadata:](https://www.elastic.co/guide/en/elasticsearch/guide/current/_document_metadata.html)

1. **_index** - Where the document lives
2. **_type** - The class of object that the document represents
3. **_id** - The unique identifier for the document

#### [Core Simple Field Types:](https://www.elastic.co/guide/en/elasticsearch/guide/current/mapping-intro.html)

1.	**String:** string
2.	**Whole number:** byte, short, integer, long
3.	**Floating-point:** float, double
4.	**Boolean:** boolean
5.	**Date:** date

# Additional Info

Elasticsearch is an open-source search engine built on top of [Apache Lucene](https://lucene.apache.org/core/)

### Quering:

Query Format:

	<REST Verb> /<Index>/<Type>/<Id>
	curl -X<VERB> '<PROTOCOL>://<HOST>:<PORT>/<PATH>?<QUERY_STRING>' -d '<BODY>'

Query Sameples:

	GET /_cluster/health

	GET /_mapping

	PUT /{index}/{type}/{id}
	{
	  "field": "value",
	  ...
	}

	GET /_analyze
	{
	  "analyzer": "standard",
	  "text": "Text to analyze"
	}

	GET /_analyze 
	{
	  "analyzer": "standard", 
	  "text": ["Hellow Word 101"]
	}

	GET /{index}/_analyze
	{
	  "field": "{fieldName}",
	  "text": "Black-cats" 
	}

    GET /_search

### [Search all types in all indices:](https://www.elastic.co/guide/en/elasticsearch/guide/current/multi-index-multi-type.html)

1. `/gb/_search` - Search all types in the gb index
2. `/gb,us/_search` - Search all types in the gb and us indices
3. `/g*,u*/_search` - Search all types in any indices beginning with g or beginning with u
4. `/gb/user/_search` - Search type user in the gb index
5. `/gb,us/user,tweet/_search` - Search types user and tweet in the gb and us indices
6. `/_all/user,tweet/_search` - Search types user and tweet in all indices

#### [Combining Multiple Clauses:](https://www.elastic.co/guide/en/elasticsearch/guide/current/query-dsl-intro.html)

    {
        "bool": {
            "must":     { "match": { "tweet": "elasticsearch" }},
            "must_not": { "match": { "name":  "mary" }},
            "should":   { "match": { "tweet": "full text" }},
            "filter":   { "range": { "age" : { "gt" : 30 }} }
        }
    }

#### Most Important Queries:

**match_all**

```{ "match_all": {}}```

**match**

```{ "match": { "tweet": "About Search" }}```

**multi_match**

```
{
 	"multi_match": {
		"query":    "full text search",
		"fields":   [ "title", "body" ]
	}
}
```

**range**

```
{
	"range": {
		"age": {
			"gte":  20,
			"lt":   30
		}
	}
}
```
	
**term**

```
{ "term": { "age":    26           }}
{ "term": { "date":   "2014-09-01" }}
{ "term": { "public": true         }}
{ "term": { "tag":    "full_text"  }}
```

**terms**
		
```{ "terms": { "tag": [ "search", "full_text", "nosql" ] }}```
	
**exists and missing**

```
{
	"exists": {
  		"field": "title"
	}
}
```

#### [Combining Queries Together:](https://www.elastic.co/guide/en/elasticsearch/guide/current/combining-queries-together.html)

1.	**must** - Clauses that must match for the document to be included.
2.	**must_not** - Clauses that must not match for the document to be included.
3.	**should** - If these clauses match, they increase the _score; otherwise, they have no effect.
4.	**filter** - Clauses that must match, but are run in non-scoring, filtering mode.

# LINKS:

1.	[Building a simple spell corrector with elasticsearch](https://arjunjs.wordpress.com/2017/04/12/elasticsearch-building-a-simple-spell-corrector-with-elasticsearch/)
2.	[Guide - The Empty Search](https://www.elastic.co/guide/en/elasticsearch/guide/current/empty-search.html)
3.	[How to Use Fuzzy Searches in Elasticsearch](https://www.elastic.co/blog/found-fuzzy-search)


# FUZZY QUERY:

#### Search query example:

```
GET /_search
{
    "query": {
        "fuzzy" : {
            "user" : {
                "value" :         "ki",
                    "boost" :         1.0,
                    "fuzziness" :     2,
                    "prefix_length" : 0,
                    "max_expansions": 100
            }
            }
        }
    }
}
```

#### Parameters:

1. `fuzziness` - The maximum edit distance. Defaults to AUTO. See Fuzzinessedit.
2. `prefix_length` - The number of initial characters which will not be “fuzzified”. This helps to reduce the number of terms which must be examined. Defaults to 0.
3. `max_expansions` - The maximum number of terms that the fuzzy query will expand to. Defaults to 50.

Links:

1.	[Reference - Fuzzy Query](https://www.elastic.co/guide/en/elasticsearch/reference/5.5/query-dsl-fuzzy-query.html)
2.	[Guide - Fuzzy Query](https://www.elastic.co/guide/en/elasticsearch/guide/current/fuzzy-query.html)
3.	[Fuzzy Query Usage](https://www.elastic.co/guide/en/elasticsearch/client/net-api/current/fuzzy-query-usage.html)


# [Analysis](https://www.elastic.co/guide/en/elasticsearch/reference/2.3/analysis.html)

1. Analyzers
2. Tokenizers
3. Token Filters
4. Character Filters

Links:

1. [Reference - Custom Analyzer](https://www.elastic.co/guide/en/elasticsearch/reference/current/analysis-custom-analyzer.html)
2. [Reference - Update Indices Settings](https://www.elastic.co/guide/en/elasticsearch/reference/master/indices-update-settings.html)
3. [Guide - Custom Analyzers](https://www.elastic.co/guide/en/elasticsearch/guide/current/custom-analyzers.html)
4. [Guide - Char Filters](https://www.elastic.co/guide/en/elasticsearch/guide/current/char-filters.html)
5. [Guide - Using Language Analyzers](https://www.elastic.co/guide/en/elasticsearch/guide/current/using-language-analyzers.html)
6. [Guide - Analysis and Analyzers](https://www.elastic.co/guide/en/elasticsearch/guide/current/analysis-intro.html)


# [The Different Types of Fuzzy Searches](https://www.elastic.co/blog/found-fuzzy-search#the-different-types-of-fuzzy-searches)

Multiple types of fuzzy search are supported by elasticsearch and the differences can be confusing. The list below attempts to disambiguate these various types.

1. `match query` + fuzziness option: Adding the fuzziness parameter to a match query turns a plain match query into a fuzzy one. Analyzes the query text before performing the search.
2. `fuzzy query`: The elasticsearch fuzzy query type should generally be avoided. Acts much like a term query. Does not analyze the query text first.
3. `fuzzy_like_this/fuzzy_like_this_field`: A more_like_this query, but supports fuzziness, and has a tuned scoring algorithm that better handles the characteristics of fuzzy matched results.*
4. `suggesters`: Suggesters are not an actual query type, but rather a separate type of operation (internally built on top of fuzzy queries) that can be run either alongside a query, or independently. Suggesters are great for 'did you mean' style functionality.

# [Mapping Char Filter](https://www.elastic.co/guide/en/elasticsearch/reference/2.3/analysis-mapping-charfilter.html)
```
POST /people/_close
PUT /people/_settings
{
  "analysis": {
    "char_filter": {
      "quotes" : {
        "type" : "mapping",
        "mappings": [
            "გ=>g",
            "ი=>i",
            "ო=>o",
            "რ=>r"
          ]
      }
    },
    "analyzer": {
      "gA": {
        "tokenizer": "standard",
        "char_filter": ["quotes"]
      }
    }
  }
}
POST /people/_open
```



# About ElasticClient DI
    
[Elasticsearch Client Lifetimes](https://www.elastic.co/guide/en/elasticsearch/client/net-api/current/lifetimes.html)