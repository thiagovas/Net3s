using System.Collections.Generic;
using System.Runtime.Serialization;
using System;

namespace Models.AtualizacaoEmDesuso
{
    #region === Exemplo de classe modelo de um documento JSON ===
    /*
//[DataContract(Name="Usuario")]
[DataContract]
public class Usuario
{
[DataMember]
public string Nome { get; set; }

[DataMember]
public string Endereco { get; set; }

[DataMember]
public List<string> Telefones { get; set; }
}
 */
    #endregion

    #region === Exemplo de um feed em JSON ===
    //Retirado do link: http://beautifulbeta.wikidot.com/json-feeds

    /*{
"version" : "1.0",
"encoding" : "UTF-8",
"feed" : { 
  "xmlns" : "http://www.w3.org/2005/Atom",
  "xmlns$openSearch" : "http://a9.com/-/spec/opensearchrss/1.0/",
  "id" : { "$t" : "tag:blogger.com,1999:blog-934829683866516411" },
  "updated" : { "$t" : "2007-03-18T20:43:19.434+01:00" },
  "title" : {
    "type" : "text",
    "$t" : "Beautiful Beta" 
   },
  "link" : [ {
    "rel" : "alternate",
    "type" : "text/html",
    "href" : "http://beautifulbeta.blogspot.com/index.html"
    },{
    "rel" : "next",
    "type" : "application/atom+xml",
    "href" : "http://beautifulbeta.blogspot.com/feeds/posts/default?alt=json-in-script&start-index=26&max-results=25"
    },{
    "rel" : "http://schemas.google.com/g/2005#feed",
    "type" : "application/atom+xml",
    "href" : "http://beautifulbeta.blogspot.com/feeds/posts/default"
    },{
    "rel" : "self",
    "type" : "application/atom+xml",
    "href" : "http://beautifulbeta.blogspot.com/feeds/posts/default?alt=json-in-script"
    } ],
  "author" : [ { 
    "name" : { "$t" : "Beta Bloke" }
  } ],
  "generator" : {
    "version" : "7.00",
    "uri" : "http://www2.blogger.com",
    "$t" : "Blogger"
  },
  "openSearch$totalResults" : { "$t" : "74" },
  "openSearch$startIndex" : { "$t" : "1" },
  "entry" : [ {
    "id" : { "$t" : "tag:blogger.com,1999:blog-934829683866516411.post-8097606299472435819" }, 
    "published" : { "$t" : "2007-03-18T12:27:00.000+01:00" },
    "updated" : { "$t" : "2007-03-18T12:35:19.236+01:00" },
    "category" : [ {
      "scheme" : "http://www.blogger.com/atom/ns#",
      "term" : "tools"
     } ],
    "title" : {
      "type" : "text",
      "$t" : "What's Up Here"
    },
    "content" : {
      "type" : "html",
      "$t" : "It has been very quiet on ....."
    },
    "link" : [ {
      "rel" : "alternate",
      "type" : "text/html",
      "href" : "http://beautifulbeta.blogspot.com/2007/03/whats-up-here.html"
      },{
      "rel" : "self",
      "type" : "application/atom+xml",
      "href" : "http://beautifulbeta.blogspot.com/feeds/posts/default/8097606299472435819"
      },{
      "rel" : "edit",
      "type" : "application/atom+xml",
      "href" : "http://www.blogger.com/feeds/934829683866516411/posts/default/8097606299472435819"
    } ],
    "author" : [ {
      "name" : { "$t" : "Beta Bloke" }
    } ]
  } ]
}}
     */
    #endregion

    //http://www.phdcc.com/xml2json.htm

    [DataContract(Name="rss")]
    [Obsolete("Esta classe so será usada se o sistema de feeds voltar a ser usado para mecher com as atualizações de usuários.")]
    public class Feed
    {
        [DataMember(Name="version", Order=1)]
        private string AttributeVersion = "2.0";

        [DataMember(Name="Xmlns:Atom", Order=2)]
        private string AttributeXmlnsAtom = @"http://www.w3.org/2005/Atom";

        [DataMember(Name="Channel")]
        public Channel c { get; set; }
    }

    [Obsolete("Esta classe so será usada se o sistema de feeds voltar a ser usado para mecher com as atualizações de usuários.")]
    public class Channel
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name="link")]
        public string Link { get; set; }

        [DataMember(Name="description")]
        public string Description { get; set; }

        [DataMember(Name="language")]
        public string Language { get; set; }

        [DataMember(Name="pubDate")]
        public string PubDate { get; set; }

        [DataMember(Name="lastBuildDate")]
        public string LastBuildDate { get; set; }

        [DataMember(Name="webMaster")]
        public string WebMaster { get; set; }

        [DataMember(Name="image")]
        public Image ObjImage { get; set; }

        [DataMember(Name="atom:link")]
        public AtomLink ObjAtomLink { get; set; }

        [DataMember(Name="item")]
        public List<Item> LstItens { get; set; }
    }

    [Obsolete("Esta classe so será usada se o sistema de feeds voltar a ser usado para mecher com as atualizações de usuários.")]
    public class Image
    {
        [DataMember(Name="title")]
        public string Title { get; set; }

        [DataMember(Name="url")]
        public string Url { get; set; }

        [DataMember(Name="link")]
        public string Link { get; set; }

        [DataMember(Name="description")]
        public string Description { get; set; }
    }

    [Obsolete("Esta classe so será usada se o sistema de feeds voltar a ser usado para mecher com as atualizações de usuários.")]
    public class AtomLink 
    {
        [DataMember(Name="href")]
        public string AttributeHref { get; set; }

        [DataMember(Name="rel")]
        public string AttributeRel { get; set; }

        [DataMember(Name="type")]
        public string AttributeType { get; set; }
    }

    [Obsolete("Esta classe so será usada se o sistema de feeds voltar a ser usado para mecher com as atualizações de usuários.")]
    public class Item 
    {
        [DataMember(Name="title")]
        public string Title { get; set; }

        [DataMember(Name="description")]
        public string Description { get; set; }

        [DataMember(Name="link")]
        public string Link { get; set; }

        [DataMember(Name="guid")]
        public string Guid { get; set; }
    }
}