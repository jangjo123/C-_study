using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MMO_EFCore
{
    // 오늘의 주제 : Backing Field + Relationship
    // Backing Field -> private field를 DB에 매핑
    // Navigation Property 에서도 사용 가능
    
    public class ItemReview
    {
        public int ItemReviewId { get; set; }
        public int Score { get; set; } // 0~5점

    }

    [Table("Item")]
    public class Item
    {
        public bool SoftDeleted { get; set; }

        // 이름Id -> PK
        public int ItemId { get; set; }
        public int TemplateId { get; set; } // 101 = 집행검
        public DateTime CreateDate { get; set; }

        // 다른 클래스 참조 -> FK (Navigational Property)
        //[ForeignKey("OwnerId")]
        public int OwnerId { get; set; }
        public Player Owner { get; set; }

        public double? AverageScore { get; set; } // 평균 별점

        private readonly List<ItemReview> _reviews = new List<ItemReview>();
        public IEnumerable<ItemReview> Reviews { get { return _reviews.ToList(); } }

        public void AddReview (ItemReview review)
        {
            _reviews.Add(review);
            AverageScore = _reviews.Average(r => r.Score);
        }

        public void RemoveReview (ItemReview review)
        {
            _reviews.Remove(review);
            AverageScore = _reviews.Any() ? _reviews.Average(r => r.Score) : (double?)null;
        }
    }

    public class EventItem : Item
    {
        public DateTime DestroyDate { get; set; }
    }

    // Entity 클래스 이름 = 테이블 이름 = Player
    [Table("Player")]
    public class Player
    {
        // 이름Id -> PK
        public int PlayerId { get; set; }

        [Required]
        [MaxLength(20)]
        // Alternate Key
        public string Name { get; set; }
        // [InverseProperty("Owner")]
        public Item OwnedItem { get; set; }
        public Guild Guild { get; set; }
    }

    [Table("Guild")]
    public class Guild
    {
        public int GuildId { get; set; }
        public string GuildName { get; set; }
        public ICollection<Player> Members { get; set; }
    }

    // DTO (Data Transfer Object)
    public class GuildDto
    {
        public int GuildId { get; set; }
        public string Name { get; set; }
        public int MemberCount { get; set; }
    }
}
