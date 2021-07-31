using UnityEngine;
using System.Collections;
using DD.Object;
using DD.AI;
using TMPro;

namespace DD.Level
{
    public class ObjectSpawner : MonoBehaviour
    {
        [SerializeField] GameObject player = null;
        [SerializeField] ActionObject objectToSpawn = null;
        [SerializeField] SpriteRenderer objectPreivew = null;

        int mouseCount = 0;

        GroundChecker groundChecker;

        private void Awake()
        {
            groundChecker = objectPreivew.GetComponent<GroundChecker>();
        }

        private void Start()
        {
            objectPreivew.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (objectToSpawn == null) return;

            HandleSpawn();
        }

        private void HandleSpawn()
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 spawnPos = mousePos + new Vector2(0f, 0.5f);
            UpdatePreviewStatus(spawnPos);

            if (Input.GetMouseButtonDown(0))
            {
                mouseCount++;

                if (mouseCount < 2) return;

                objectPreivew.gameObject.SetActive(true);
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (mouseCount < 2) return;

                if (groundChecker.IsOnGround())
                {
                    ActionObject actionObject = Instantiate(objectToSpawn, spawnPos, Quaternion.identity);

                    if (actionObject.type == ObjectType.enemy)
                    {
                        actionObject.GetComponent<EnemyController>().SetPlayer(player);
                    }
                }

                objectPreivew.gameObject.SetActive(false);
                FindObjectOfType<PlayData>().UseCoin(objectToSpawn.profile.cost);
            }
        }

        public void Activate(ActionObject objectToSpawn)
        {
            this.objectToSpawn = objectToSpawn;
            objectPreivew.sprite = objectToSpawn.profile.repSprite;
        }

        public void Deactivate()
        {
            objectToSpawn = null;
            mouseCount = 0;
        }

        private void UpdatePreviewStatus(Vector2 spawnPos)
        {
            objectPreivew.transform.position = spawnPos;

            if (!groundChecker.IsOnGround()) objectPreivew.color = new Color(1, 0, 0, 0.5f);
            else objectPreivew.color = new Color(1, 1, 1, 0.5f);
        }
    }
}
