using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Category : Entity
    {
        private readonly List<Article> _articles = new List<Article>();
        public string Name { get; private set; }
        public IReadOnlyCollection<Article> Atricles => _articles;

        public void AddArticle(Article article)
        {
            _articles.Add(article);
        }

        public void RemoveArticle(Article article)
        {
            _articles.Remove(article);
        }

    }
}
