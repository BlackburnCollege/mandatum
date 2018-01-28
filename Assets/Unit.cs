using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mandatum {
    public abstract class Unit : MonoBehaviour {
        public int damage = 1;
        public int health = 10;
        public int speed = 2;
        public bool ignoreTerrain = false;
        private Vector2 gridPosition;
        public virtual Vector2 GridPosition {
            get {
                return gridPosition;
            }
            set {
                gridPosition = value;
            }
        }

        public abstract int[] GetDamage(Unit other);
        public abstract void killUnit();

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }
    }
}