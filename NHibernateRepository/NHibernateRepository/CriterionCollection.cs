using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Criterion;

namespace NHibernateRepository
{
    public class CriterionCollection : IEnumerable<ICriterion>, IEquatable<CriterionCollection>
    {
        private readonly IList<ICriterion> _collection;
        
        public CriterionCollection()
        {
            _collection = new List<ICriterion>();
        }

        public void Add(ICriterion criteria)
        {
            if (criteria == null) 
                throw new ArgumentNullException("criteria");

            if (_collection != null)
                _collection.Add(criteria);
        }

        public int Count { get { return _collection.Count; } }

        #region Implementation of IEnumerable

        public IEnumerator<ICriterion> GetEnumerator()
        {
            return _collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Equality members

        public bool Equals(CriterionCollection other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            if (_collection.Count != other._collection.Count)
                return false;

            for (int i = 0; i < _collection.Count; i++)
            {
                if (!_collection.ElementAt(i).ToString()
                        .Equals(other._collection.ElementAt(i).ToString()))
                    return false;
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((CriterionCollection) obj);
        }

        public override int GetHashCode()
        {
            return _collection.GetHashCode();
        }

        public static bool operator ==(CriterionCollection left, CriterionCollection right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CriterionCollection left, CriterionCollection right)
        {
            return !Equals(left, right);
        }

        #endregion

        public bool Empty()
        {
            return _collection.Count == 0;
        }
    }
}