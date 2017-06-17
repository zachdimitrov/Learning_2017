using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Forum.Models
{
    public class Post
    {
        private ICollection<PostAnswer> answers;
        private ICollection<Tag> tags;

        public Post()
        {
            this.CreatedOn = DateTime.Now;
            this.answers = new HashSet<PostAnswer>();
            this.tags = new HashSet<Tag>();
        }

        public int Id { get; set; }

        [MaxLength(40)]
        public string Title { get; set; }

        public string Content { get; set; }

        public PostType PostType { get; set; }

        public DateTime CreatedOn { get; set;}

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public ICollection<Tag> Tags
        {
            get { return tags; }
            set { tags = value; }
        }

        public virtual ICollection<PostAnswer> Answers
        {
            get { return answers; }
            set { answers = value; }
        }

    }
}